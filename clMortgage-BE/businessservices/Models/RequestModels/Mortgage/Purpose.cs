using System.ComponentModel;

namespace BusinessService.Model
{
    public enum Purpose
    {
        [Description("Purchase a residential property")]
        residential,
        [Description("Purchase a commercial property")]
        commercial
    }
}  