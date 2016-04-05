﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ArrayList nouns = new ArrayList();
        public ArrayList verbs = new ArrayList();
        public ArrayList adjectives = new ArrayList();
       


        public MainWindow()
        {
            InitializeComponent();
            ReadDictionary();
        }
        private void ReadDictionary()
        {
            ReadAdjectives();
            ReadNouns();
            ReadVerbs();

        }
        private void ReadNouns()
        {
            var path = @"text\noun.txt";
            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                var arr = s.Split(' ');
                foreach(string substring in arr)
                {
                    nouns.Add(substring);
                }
            }

        }
        private void ReadAdjectives()
        {
            var path = @"text\adjective.txt";
            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                var arr = s.Split(' ');
                foreach (string substring in arr)
                {
                   adjectives.Add(substring);
                }
            }
        }
        private void ReadVerbs()
        {
            var path = @"text\verb.txt";
            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                var arr = s.Split(' ');
                foreach (string substring in arr)
                {
                    verbs.Add(substring);
                }
            }

        }

        private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            
            
        }

        private void outputPoem_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            outputPoem.Document.Blocks.Clear();
            Random rnd = new Random();
            inputPoem.SelectAll();
            string[] lines = inputPoem.Selection.Text.Split('\n');
            foreach (string line in lines)
            {
                for (var i = 0; i < line.Length; i++)
                {
                    if (line[i] == '#')
                    {
                        var temp = i;
                        i = i + 1;
                        if (line[i] == 'N')
                        {
                            int r = rnd.Next(nouns.Count);

                            outputPoem.AppendText((string)nouns[r] + " ");
                        }
                        else if (line[i] == 'A')
                        {
                            int r = rnd.Next(adjectives.Count);
                            outputPoem.AppendText((string)adjectives[r] + " ");
                        }
                        else if (line[i] == 'V')
                        {
                            int r = rnd.Next(verbs.Count);
                            outputPoem.AppendText((string)verbs[r] + " ");
                        }
                        i = temp;
                    }
                }
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var win2 = new SaveWindow();;
            win2.Show();
            this.Close();

        }
    }
}