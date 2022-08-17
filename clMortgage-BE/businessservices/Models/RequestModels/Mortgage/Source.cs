using System.ComponentModel;

namespace BusinessService.Model
{
    public enum Source
    {
        Salaried,
        [Description("Self-Employee")]
        selfemployee
    }
}  