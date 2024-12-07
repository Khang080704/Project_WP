using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace KeepItFit___Project_WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NutritionResult : Window
    {
        int _result;
        public NutritionResult(int result)
        {
            this.InitializeComponent();
            _result = result;
            if(_result >= 0)
            {
                Result.Text = "Based on your total calories consumed for today, you are likely not eating enough.\r\n\r\nFor safe weight loss, the National Institutes of Health recommends no less than 1000-1200 calories for women and 1200-1500 calories for men.\r\n\r\nCompleting your diary with fewer than the minimum calories noted above will not generate a news feed post for that day, or show a five-week weight projection.\r\n\r\nEven during weight loss, it's important to meet your body's basic nutrient and energy needs. Over time, not eating enough can lead to nutrient deficiencies, unpleasant side effects & other serious health problems.";
            }
            else 
            {
                Result.Text = "If every day were like today...   You'd weigh 72.8 kg in 5 weeks";
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
