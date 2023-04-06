import { useState } from "react"

const LoginForm = (props: {
  setToken: React.Dispatch<React.SetStateAction<string>>
}) => {
  const [email, setEmail] = useState<string>("")
  const [password, setPassword] = useState<string>("")

  type LoginRequest = {
    email: string
    password: string
  }

  const login = async () => {
    if (email && password) {
      const loginRequest: LoginRequest = {
        email,
        password,
      }
      const response = await fetch("http://localhost:5010/api/auth/v1/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(loginRequest),
      })
      const data = await response.json()
      props.setToken(data.token)
    }
  }

  return (
    <div className="LoginForm">
      <h1>Login</h1>
      <form action="#">
        <div>
          <input
            type="email"
            name="email"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>

        <div>
          <input
            type="password"
            name="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>

        <div>
          <button type="button" onClick={login} style={{ marginTop: "10px" }}>
            Login
          </button>
        </div>
      </form>
    </div>
  )
}

export default LoginForm