using MasterMind.Models;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind.WPF.Models
{
    /// <summary>
    /// Contains the same information as <see cref="Round"/>, however formatted in a way which is easier for WPF data binding.
    /// </summary>
    public class DesktopRound
    {
        #region Public

        /// <summary>
        /// Contains what player wrote. For example, 'cmyk'.
        /// </summary>
        public List<Answer> Input { get; set; }

        /// <summary>
        /// Contains the tip for the player. For example, 'wwwb'.
        /// </summary>
        public List<Answer> Output { get; set; }

        #endregion Public

        /// <summary>
        /// Creates new instance of a round based on the <see cref="Round"/>
        /// </summary>
        /// <param name="round">Contains information about player's input and output.</param>
        public DesktopRound(Round round)
        {
            Input = round.Input.Select(c => new Answer(c)).ToList();
            Output = round.Output.Select(c => new Answer(c)).ToList();
        }
    }
}