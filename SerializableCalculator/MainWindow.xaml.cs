using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace SerializableCalculator
{
        /// <summary>
        /// Логика взаимодействия для MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
                ObservableCollection<Operation> operationlist = new ObservableCollection<Operation>();
                AddPointHandler pointhandler = new AddPointHandler();
               
                public MainWindow()
                {
                        InitializeComponent();
                        this.DataContext = this;
                        OperationsListBox.ItemsSource = operationlist;
                }

                public ObservableCollection<Operation> OperationList
                {
                        get { return this.operationlist; }
                }


                #region Methods that make calculations
                public double Multiply(string firstargument, string secondargument)
                {
                        
                       return Double.Parse(firstargument) * Double.Parse(secondargument);
                }

                public double Summ(string firstargument, string secondargument)
                {
                        return Double.Parse(firstargument) + Double.Parse(secondargument);
                }

                public double Minus(string firstargument, string secondargument)
                {
                        return Double.Parse(firstargument) - Double.Parse(secondargument);
                }

                public double Divide(string firstargument, string secondargument)
                {
                        
                         return Double.Parse(firstargument) / Double.Parse(secondargument);
                }
                
                public void CalculateResult()
                {
                        if (!CheckOperationSymbolsDublicates(UserInputBox.Text)) return;

                        else
                        {
                                string result = DefineOperation().ToString();
                                string operation = UserInputBox.Text;
                                UserInputBox.Text = result;
                                operationlist.Add(new Operation(operation, result));


                        }
                }
                #endregion

                public bool CharIsOperationSymbol(char symbol)
                {
                        // This method used in SeparateFirstArgument and SeparateSecondArgument methods.
                        if ((symbol == '+') || (symbol == '/') || (symbol == '-') || (symbol == '*'))
                                return true;

                        else return false;
                }
                 
                public bool OperationListEmpty()
                {
                        if (this.operationlist.Count == 0) return true;
                        else return false;
                }
                                             
                public string SeparateFirstArgument(string userinput)
                {
                        // That method used to separate the first argument when user click equal button.
                        if (userinput == String.Empty) return string.Empty;

                        char[] userinputchar = userinput.ToCharArray();
                        int operationsymbolindex = 0;
                        

                        for (int i = 0; i < userinputchar.Length;i++)
                        {
                                if (CharIsOperationSymbol(userinputchar[i]))
                                {
                                        operationsymbolindex = i;
                                        break;
                                }
                                        
                                

                        }

                        char[] firstargument = new char[operationsymbolindex];
                        
                        for (int i = 0; i < firstargument.Length;i++)
                        {
                                firstargument[i] = userinputchar[i];
                        }

                       
                        return new string(firstargument);
                }

                public string SeparateSecondArgument(string userinput)
                {
                        // That method used to separate the second argument when user click equal button.
                        if (userinput == string.Empty) return String.Empty;

                        char[] userinputchar = userinput.ToCharArray();
                        int operationsymbolindex = 0;
                        

                        for (int i = 0; i < userinputchar.Length;i++)
                        {
                                if (CharIsOperationSymbol(userinputchar[i]))
                                {
                                        operationsymbolindex = i;
                                        break;
                                }
                                        
                                
                        }

                        char[] secondargument = new char[(userinput.Length - 1) - operationsymbolindex];
                        int copyindex = operationsymbolindex + 1;

                        for (int i = 0; i < secondargument.Length;i++)
                        {
                                secondargument[i] = userinputchar[copyindex];
                                copyindex++;
                        }

                       
                        return new string(secondargument);

                }

            
                public void Invert()
                {
                        
                        UserInputBox.Text = InvertOperation(UserInputBox.Text);
                }

                public void Clear()
                {
                        //Clears UserInputBox.
                        UserInputBox.Text = String.Empty;
                }

                public string InvertOperation(string userinput)
                {
                        // Method that handles user's click on invert button. Replacing arguments in UserInputBox.
                        if (!CheckOperationSymbolsDublicates(userinput)) return userinput;

                        char[] userinputchar = userinput.ToCharArray();
                        char[] inverted = new char[userinput.Length];
                        int operationsymbolindex = 0;
                        int copyafteroperationsymbol = 0;
                        int copybeforeoperationsymbol = 0;

                        for (int i = 0; i < userinputchar.Length;i++)
                        {
                                if (CharIsOperationSymbol(userinputchar[i]))
                                        operationsymbolindex = i;
                        }

                        for (int i = operationsymbolindex + 1; i < userinputchar.Length;i++)
                        {
                                inverted[copyafteroperationsymbol] = userinputchar[i];
                                copyafteroperationsymbol++;
                        }

                        inverted[copyafteroperationsymbol] = userinputchar[operationsymbolindex];

                        for (int i = copyafteroperationsymbol + 1; i < inverted.Length;i++)
                        {
                                inverted[i] = userinputchar[copybeforeoperationsymbol];
                                copybeforeoperationsymbol++;
                        }

                        return new string(inverted);

                }
                  
                
                public double DefineOperation()
                {
                        // This Method is being called when user clicks equal button or presses enter.
                        if (UserInputBox.Text.Contains('+'))
                        {
                                return Summ(SeparateFirstArgument(UserInputBox.Text), SeparateSecondArgument(UserInputBox.Text));
                        }
                       

                        if (UserInputBox.Text.Contains('-'))
                        {
                                return Minus(SeparateFirstArgument(UserInputBox.Text), SeparateSecondArgument(UserInputBox.Text));
                        }

                        if (UserInputBox.Text.Contains('*'))
                        {
                                return Multiply(SeparateFirstArgument(UserInputBox.Text), SeparateSecondArgument(UserInputBox.Text));
                        }

                        if (UserInputBox.Text.Contains('/'))
                        {
                                return Divide(SeparateFirstArgument(UserInputBox.Text), SeparateSecondArgument(UserInputBox.Text));
                        }

                        else return 0;                               
                                   
                        
                }

                
                public bool CheckOperationSymbolsDublicates(string userinput)
                {// This Method used to prevent user from entering double operation symbol.
                        if ((userinput.Contains('*')) || (userinput.Contains('/')) ||
                             (userinput.Contains('+')) || (userinput.Contains('-')))
                                return true;

                        else return false;
                }

                #region ButtonClick Event Handlers
                
                public void OnOneButtonClick(object sender, RoutedEventArgs e)
                {
                        AddOne();
                }

                public void OnTwoButtonClick(object sender, RoutedEventArgs e)
                {
                        AddTwo();
                }
                
                public void OnThreeButtonClick(object sender, RoutedEventArgs e)
                {
                        AddThree();
                }

                public void OnFourButtonClick(object sender, RoutedEventArgs e)
                {
                        AddFour();
                }

                public void OnFiveButtonClick(object sender, RoutedEventArgs e)
                {
                        AddFive();
                }

                public void OnSixButtonClick(object sender, RoutedEventArgs e)
                {
                        AddSix();
                }

                public void OnSevenButtonClick(object sender, RoutedEventArgs e)
                {
                        AddSeven();
                }

                public void OnEightButtonClick(object sender, RoutedEventArgs e)
                {
                        AddEight();
                }

                public void OnNineButtonClick(object sender, RoutedEventArgs e)
                {
                        AddNine();
                }

                public void OnZeroButtonClick(object sender, RoutedEventArgs e)
                {
                        AddZero();
                }

                public void OnPointButtonClick(object sender, RoutedEventArgs e)
                {
                       
                       AddPoint();
                }

                public void OnClearButtonClick(object sender, RoutedEventArgs e)
                {
                        Clear();
                }

                public void OnPlusButtonClick(object sender, RoutedEventArgs e)
                {
                        if (CheckOperationSymbolsDublicates(UserInputBox.Text)) return;
                        else AddPlus();
                }

                public void OnMinusButtonClick(object sender, RoutedEventArgs e)
                {
                        if (CheckOperationSymbolsDublicates(UserInputBox.Text)) return;
                        else AddMinus();
                }

                public void OnDivideButtonClick(object sender, RoutedEventArgs e)
                {
                        if (CheckOperationSymbolsDublicates(UserInputBox.Text)) return;
                        else AddDivide();
                }

                public void OnMultiplyButtonClick(object sender, RoutedEventArgs e)
                {
                        if (CheckOperationSymbolsDublicates(UserInputBox.Text)) return;
                        else AddMultiply();
                }

                public void OnEqualButtonClick(object sender, RoutedEventArgs e)
                {
                        CalculateResult();
                }

                public void OnInvertButtonClick(object sender, RoutedEventArgs e)
                {
                        Invert();
                }

                public void OnSaveButtonClick(object sender, RoutedEventArgs e)
                {
                        if (OperationListEmpty()) return;

                        SaveWindow sv = new SaveWindow(operationlist);
                        sv.Show();
                }
                #endregion

                #region Methods that adds symbols to UserInput TextBlock.
                //  This methods are used in Button Click Handlers and Keyboard Event Handlers.
                public void AddZero()
                {
                        UserInputBox.Text = UserInputBox.Text + '0';
                }

                public void AddOne()
                {
                        UserInputBox.Text = UserInputBox.Text + '1';
                }

                public void AddTwo()
                {
                        UserInputBox.Text = UserInputBox.Text + '2';
                }

                public void AddThree()
                {
                        UserInputBox.Text = UserInputBox.Text + '3';
                }

                public void AddFour()
                {
                        UserInputBox.Text = UserInputBox.Text + '4';
                }

                public void AddFive()
                {
                        UserInputBox.Text = UserInputBox.Text + '5';
                }

                public void AddSix()
                {
                        UserInputBox.Text = UserInputBox.Text + '6';
                }

                public void AddSeven()
                {
                        UserInputBox.Text = UserInputBox.Text + '7';
                }

                public void AddEight()
                {
                        UserInputBox.Text = UserInputBox.Text + '8';
                }

                public void AddNine()
                {
                        UserInputBox.Text = UserInputBox.Text + '9';
                }

                public void AddPoint()
                {
                       if (pointhandler.AllowAddPoint(UserInputBox.Text))
                        {
                                UserInputBox.Text = UserInputBox.Text + ',';
                        }
                       
                }

                public void AddDivide()
                {
                        if (CheckOperationSymbolsDublicates(UserInputBox.Text)) return;
                        else UserInputBox.Text = UserInputBox.Text + '/';
                }

                public void AddMultiply()
                {
                        if (CheckOperationSymbolsDublicates(UserInputBox.Text)) return;
                        else UserInputBox.Text = UserInputBox.Text + '*';
                }

                public void AddPlus()
                {
                        if (CheckOperationSymbolsDublicates(UserInputBox.Text)) return;
                        else  UserInputBox.Text = UserInputBox.Text + '+';
                }

                public void AddMinus()
                {
                        if (CheckOperationSymbolsDublicates(UserInputBox.Text)) return;
                        else UserInputBox.Text = UserInputBox.Text + '-';
                }
                #endregion
                // Method to Handle KeyboardInput.
                public void KeyBoardEventHandler(object sender, KeyEventArgs e)
                {
                        if (e.Key == Key.D0 || e.Key == Key.NumPad0) AddZero();
                        if (e.Key == Key.D1 || e.Key == Key.NumPad1) AddOne();
                        if (e.Key == Key.D2 || e.Key == Key.NumPad2) AddTwo();
                        if (e.Key == Key.D3 || e.Key == Key.NumPad3) AddThree();
                        if (e.Key == Key.D4 || e.Key == Key.NumPad4) AddFour();
                        if (e.Key == Key.D5 || e.Key == Key.NumPad5) AddFive();
                        if (e.Key == Key.D6 || e.Key == Key.NumPad6) AddSix();
                        if (e.Key == Key.D7 || e.Key == Key.NumPad7) AddSeven();
                        if (e.Key == Key.D8 || e.Key == Key.NumPad8) AddEight();
                        if (e.Key == Key.D9 || e.Key == Key.NumPad9) AddNine();
                        if (e.Key == Key.Decimal || e.Key == Key.OemComma) AddPoint();
                        if (e.Key == Key.OemPlus) AddPlus();
                        if (e.Key == Key.OemMinus) AddMinus();
                        if (e.Key == Key.Divide) AddDivide();
                        if (e.Key == Key.Multiply) AddMultiply();
                        if (e.Key == Key.Enter) CalculateResult();
                        if (e.Key == Key.I) Invert();
                        if (e.Key == Key.C) Clear();
                }
        }
}
