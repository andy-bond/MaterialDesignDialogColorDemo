using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace MaterialDesignDialogColorDemo
{
    /// <summary>
    /// Interaction logic for SettingsDialog.xaml
    /// </summary>
    public partial class SettingsDialog : UserControl
    {
        // Get all of the swatches
        private IEnumerable<Swatch> Swatches = new SwatchesProvider().Swatches;

        public SettingsDialog()
        {
            InitializeComponent();

            // Get the Current Palette (Why is there no .IsDark on the Palette?)
            Palette current_palette = new PaletteHelper().QueryPalette();

            // Set all ToggleButtons to the value they should be on
            LightDark_ToggleBTN.IsChecked = !(((SolidColorBrush)SettingsCard.Background).Color == Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
            Primary_ToggleBTN.IsChecked = !(current_palette.PrimarySwatch.Name == "indigo");
            Accent_ToggleBTN.IsChecked = !(current_palette.AccentSwatch.Name == "red");
        }

        // Toggle Light/Dark
        // This will have no effect on the Dialog Card
        private void LightDark_ToggleBTN_Click(object sender, RoutedEventArgs e)
        {
            new PaletteHelper().SetLightDark((bool)LightDark_ToggleBTN.IsChecked);
        }

        // Toggle Primary Color
        // This will work as expected
        private void Primary_ToggleBTN_Click(object sender, RoutedEventArgs e)
        {
            Swatch original_swatch = Swatches.First(i => i.Name == "indigo");
            Swatch new_swatch = Swatches.First(i => i.Name == "grey");

            new PaletteHelper().ReplacePrimaryColor((Primary_ToggleBTN.IsChecked == true) ? new_swatch : original_swatch);
        }

        // Toggle Accent Color
        // This will work as expected
        private void Accent_ToggleBTN_Click(object sender, RoutedEventArgs e)
        {
            Swatch original_swatch = Swatches.First(i => i.Name == "red");
            Swatch new_swatch = Swatches.First(i => i.Name == "yellow");

            new PaletteHelper().ReplaceAccentColor((Accent_ToggleBTN.IsChecked == true) ? new_swatch : original_swatch);
        }

        
    }
}
