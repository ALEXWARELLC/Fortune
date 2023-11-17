using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Fortune;

public class Config : IConfig
{
    [Description("Is the Fortune Flip plugin enabled?")]
    public bool IsEnabled { get; set; }

    [Description("This does nothing. No need to activate this.")]
    public bool Debug { get; set; }

    [Description("Maximum range for the random number generator.")]
    public int ActivationMax { get; set; } = 10;

    [Description("The maximum number required to apply random effect.")]
    public int ActivationChance { get; set; } = 3;
}
