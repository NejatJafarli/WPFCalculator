using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCalculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			for (int i = 0; i < UselessButtonsGrid.Children.Count; i++)
			{
				if (UselessButtonsGrid.Children[i] is Button btn)
				{
					BrushConverter bc = new BrushConverter();
					Brush Color = (Brush)bc.ConvertFrom("#FFFFFF");
					Color.Freeze();
					btn.Foreground = Color;
				}
			}
		}

		private void NumberButton_Click(object sender, RoutedEventArgs e)
		{
			if (sender is Button btn)
			{
				switch (btn.Content)
				{
					case "0":
						txt.Content += "0";
						break;
					case "1":
						txt.Content += "1";
						break;
					case "2":
						txt.Content += "2";
						break;
					case "3":
						txt.Content += "3";
						break;
					case "4":
						txt.Content += "4";
						break;
					case "5":
						txt.Content += "5";
						break;
					case "6":
						txt.Content += "6";
						break;
					case "7":
						txt.Content += "7";
						break;
					case "8":
						txt.Content += "8";
						break;
					case "9":
						txt.Content += "9";
						break;
					default:
						break;
				}
			}
		}

		private void BackSpaceButton(object sender, RoutedEventArgs e)
		{
			if (txt.Content.ToString() != "")
				if (txt.Content.ToString().Contains('-') && txt.Content.ToString().Length == 2)
					txt.Content = txt.Content.ToString().Substring(0, txt.Content.ToString().Length - 2);
				else
					txt.Content = txt.Content.ToString().Substring(0, txt.Content.ToString().Length - 1);
		}

		private void NegativePositive(object sender, RoutedEventArgs e)
		{
			if (txt.Content.ToString() != "")
			{
				if (txt.Content.ToString()[0] == '-')
				{
					txt.Content = txt.Content.ToString().Split('-')[1];
				}
				else
				{
					string temp = $"-{txt.Content}";
					txt.Content = temp;
				}
			}
		}

		private void DotButtonClicked(object sender, RoutedEventArgs e)
		{
			if (txt.Content.ToString() != "" && !txt.Content.ToString().Contains(','))
				txt.Content += ",";
		}
		public char? Operator { get; set; }
		public double? NumberOne { get; set; } = null;
		private void ClearButtonClicked(object sender, RoutedEventArgs e)
		{
			NumberOne = null;
			Operator = null;
			label2.Content = "";
			label1.Content = "";
			txt.Content = "";
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			txt.Content = "";
		}

		private void OperatorButtonsClicked(object sender, RoutedEventArgs e)
		{
			if (sender is Button btn)
			{
				if (txt.Content.ToString() != "")
				{
					if (!(NumberOne is null))
					{
						switch (Operator)
						{
							case '+':
								NumberOne += Convert.ToDouble(txt.Content.ToString());
								break;
							case '-':
								NumberOne -= Convert.ToDouble(txt.Content.ToString());
								break;
							case '✕':
								NumberOne *= Convert.ToDouble(txt.Content.ToString());
								break;
							case '÷':
								if (NumberOne.ToString()[0] == '0')
								{
									MessageBox.Show("You Cant Divide Zero");
								}
								else
									NumberOne /= Convert.ToDouble(txt.Content.ToString());
								break;
						}
						Operator = btn.Content.ToString()[0];
						label2.Content = Operator;
						txt.Content = "";
						label1.Content = NumberOne.ToString();
					}
					else
					{
						Operator = btn.Content.ToString()[0];
						label2.Content = Operator;
						NumberOne = Convert.ToDouble(txt.Content.ToString());
						if (NumberOne.ToString().StartsWith("0") && Operator != '-' && Operator != '+')
						{
							Operator = null;
							label1.Content = "";
							label2.Content = Operator;
							NumberOne = null;
							MessageBox.Show("You Cannot Divide Or Multiply Zero");
						}
						else
						{

							txt.Content = "";
							label1.Content = NumberOne.ToString();
						}
					}
				}
			}
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(txt.Content.ToString()))
			{
				switch (Operator)
				{
					case '+':
						txt.Content = (NumberOne + Convert.ToDouble(txt.Content.ToString())).ToString();
						break;
					case '-':
						txt.Content = (NumberOne - Convert.ToDouble(txt.Content.ToString())).ToString();
						break;
					case '✕':
						txt.Content = (NumberOne * Convert.ToDouble(txt.Content.ToString())).ToString();
						break;
					case '÷':
						txt.Content = (NumberOne / Convert.ToDouble(txt.Content.ToString())).ToString();
						break;
				}
				NumberOne = null;
				Operator = null;
				label1.Content = "";
				label2.Content = "";
			}
			else
			{
				txt.Content = $"{NumberOne}";
				NumberOne = null;
				Operator = null;
				label1.Content = "";
				label2.Content = "";
			}
		}

		private void MainGrid_KeyUp(object sender, KeyEventArgs e)
		{
			if (Keyboard.Modifiers==ModifierKeys.Shift && e.Key == Key.D8 )
				OperatorButtonsClicked(btnMulti, null);
			else if (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.OemPlus)
				OperatorButtonsClicked(btnPlus, null);
			else if (e.Key == Key.Oem2)
				OperatorButtonsClicked(btnDivide, null);
			else if (e.Key == Key.OemMinus)
				OperatorButtonsClicked(btnMinus, null);
			else if (e.Key == Key.OemPlus)
				Button_Click_2(null, null);
			else if (e.Key == Key.OemPeriod)
				DotButtonClicked(btnDot, null);
			else if (e.Key == Key.D1)
				NumberButton_Click(btn1, null);
			else if (e.Key == Key.D2)
				NumberButton_Click(btn2, null);
			else if (e.Key == Key.D3)
				NumberButton_Click(btn3, null);
			else if (e.Key == Key.D4)
				NumberButton_Click(btn4, null);
			else if (e.Key == Key.D5)
				NumberButton_Click(btn5, null);
			else if (e.Key == Key.D6)
				NumberButton_Click(btn6, null);
			else if (e.Key == Key.D7)
				NumberButton_Click(btn7, null);
			else if (e.Key == Key.D8)
				NumberButton_Click(btn8, null);
			else if (e.Key == Key.D9)
				NumberButton_Click(btn9, null);
			else if (e.Key == Key.Back)
				BackSpaceButton(null, null);
			else if (e.Key == Key.C)
				ClearButtonClicked(null, null);


		}
	}
}
