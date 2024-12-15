using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
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
using KeepItFit___Project_WinUI.Model;

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

        public class ViewModel
        {
            public ISeries[] Series { get; set; } = new ISeries[6];
        }

        public ViewModel viewModel { get; set; }

        public NutritionResult(Nutritions[] result)
        {
            this.InitializeComponent();
            viewModel = new ViewModel();
            _result = result[0].Remain;
            if(_result >= 0)
            {
                Result.Text = "Based on your total calories consumed for today, you are likely not eating enough.\r\n\r\nFor safe weight loss, the National Institutes of Health recommends no less than 1000-1200 calories for women and 1200-1500 calories for men.\r\n\r\nCompleting your diary with fewer than the minimum calories noted above will not generate a news feed post for that day, or show a five-week weight projection.\r\n\r\nEven during weight loss, it's important to meet your body's basic nutrient and energy needs. Over time, not eating enough can lead to nutrient deficiencies, unpleasant side effects & other serious health problems.";
            }
            else 
            {
                Result.Text = "If every day were like today...   You'd weigh 72.8 kg in 5 weeks";
            }

            int count = 0;

            for(int i = 1; i < result.Length; i++)
            {
                viewModel.Series[count++] = new PieSeries<double>
                {
                    Values = new double[] { result[i].Total },
                    Name = result[i].name
                };
            }

            NutriChart.Series = viewModel.Series;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
