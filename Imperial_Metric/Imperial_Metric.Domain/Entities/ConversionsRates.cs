using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imperial_Metric.Domain.Entities
{
    public class ConversionsRates
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public double ConversionFactor { set; get; }
        public double ConversionOffset { set; get; }
        public int ConversionId { set; get; }

        [ForeignKey("ConversionId")] public virtual Conversions Conversion{ get;set; }
    }
}
