using System;
using System.Globalization;
using System.Windows.Media;
using Answers = MasterMind.Models.Answers;
using GameColors = MasterMind.Models.Colors;

namespace MasterMind.WPF
{
    /// <summary>
    /// Converts char into SolidColorBrush for Fill property of Circle.
    /// </summary>
    internal class MasterMindColorToWpfColorValueConverter : BaseValueConverter<MasterMindColorToWpfColorValueConverter>
    {
        /// <summary>
        /// Convert from char to SolidColorBrush.
        /// </summary>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case GameColors.BLUE:
                    return new SolidColorBrush(Colors.Blue);

                case GameColors.CYAN:
                    return new SolidColorBrush(Colors.Cyan);

                case GameColors.GREEN:
                    return new SolidColorBrush(Colors.Green);

                case GameColors.MAGENTA:
                    return new SolidColorBrush(Colors.Magenta);

                case GameColors.RED:
                    return new SolidColorBrush(Colors.Red);

                case GameColors.YELLOW:
                    return new SolidColorBrush(Colors.Yellow);

                case Answers.CORRECT_ANSWER:
                    return new SolidColorBrush(Colors.Black);

                case Answers.COLOR_EXISTS:
                    return new SolidColorBrush(Colors.Gray);

                case Answers.WRONG_GUESS:
                    return new SolidColorBrush(Colors.White);

                default:
                    return new SolidColorBrush(Colors.Black);
            }
        }

        /// <summary>
        /// Backwards conversion which is not implemented.
        /// </summary>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}