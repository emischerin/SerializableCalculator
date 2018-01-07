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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SerializableCalculator
{
        /// <summary>
        /// Логика взаимодействия для SaveWindow.xaml
        /// </summary>
        public partial class SaveWindow : Window
        {
                ObservableCollection<Operation> saveoperations = new ObservableCollection<Operation>();
                private string outputfile;

                public SaveWindow(ObservableCollection<Operation> operationlist)
                {
                        InitializeComponent();
                        saveoperations = operationlist;
                }

                public void SaveToXml()
                {
                        if (outputfile != null)
                        {
                                using (Saver saver = new Saver())
                                {
                                        saver.SaveToXml(saveoperations, outputfile);
                                }
                        }
                }

                public void SaveToText()
                {
                        if (outputfile != null)
                        {

                                using (Saver saver = new Saver())
                                {
                                        saver.SaveToText(saveoperations, outputfile);
                                }
                        }
                }

                public bool SaveToXmlPreference()
                {
                        if (SelectXml.IsChecked == false) return false;

                        else return true;
                }

                public void OnSaveButtonClick(object sender, RoutedEventArgs e)
                {
                        if (SavePathTextBox.Text == null) return;

                        switch (SaveToXmlPreference())
                        {
                                case false:
                                        SaveToText();
                                        break;
                                case true:
                                        SaveToXml();
                                        break;

                        }

                        this.Close();

                                
                }

                public void OnSelectPathButtonClick(object sender, RoutedEventArgs e)
                {
                        SaveFileDialog sfd = new SaveFileDialog();
                        
                        switch(SaveToXmlPreference())
                        {
                                case true:
                                        sfd.DefaultExt = ".xml";
                                        break;
                                case false:
                                        sfd.DefaultExt = ".txt";
                                        break;
                        }

                        if (sfd.ShowDialog() == true)
                        {
                                SavePathTextBox.Text = sfd.FileName;
                                outputfile = sfd.FileName;
                        }
                        
                        
                }
        }
}
