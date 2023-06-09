import { useState } from "react";
import "./App.css";
import LoginForm from "./Components/Forms/LoginForm";
import RegisterForm from "./Components/Forms/RegisterForm";

type weatherType = {
  summary: string | undefined;
  temperature: number | undefined;
};

function App() {
  const [token, setToken] = useState<string>("");
  const [weather, setWeather] = useState<weatherType>({
    summary: undefined,
    temperature: undefined,
  });

  const getConversions = async () => {
    const response = await fetch("http://localhost:5010/api/v1/conversions", {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    const data = await response.json();

    setWeather({
      summary: data[0].summary,
      temperature: data[0].temperatureC,
    });
  };

  return (
    <div className="App">
      <RegisterForm />
      <LoginForm setToken={setToken} />
      <div style={{ marginTop: "75px" }}>
        <button onClick={getConversions} style={{ marginBottom: "10px" }}>
          Get Conversations
        </button>
        
      </div>
    </div>
  );
}

export default App;