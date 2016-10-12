using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
        public MainWindow()
        {
            InitializeComponent();
            
        }

        Assembly assebly;
        string selectedType;
        Type[] type;

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "";
            assebly = null;
            selectedType = null;
            list.Items.Clear();
            tboxPath.Clear();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            string filePath = fbd.SelectedPath;

            if (Directory.Exists(filePath))
            {
                // This path is a directory
                ProcessDirectory(filePath);
            }
            tboxPath.AppendText(filePath);
        }

        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            var files = Directory.GetFiles(targetDirectory);
            foreach (string fileName in files)
            {
                if (fileName.Contains(".dll"))
                {
                    list.Items.Add(fileName);
                }
            }
        }

        private void btnSelectDll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                label.Content = "List of Dll files";
                if (list.SelectedIndex > -1)
                {
                    assebly = Assembly.ReflectionOnlyLoadFrom(list.SelectedItem.ToString());
                    type = assebly.GetTypes();
                    list.Items.Clear();

                    foreach (var item in type)
                    {
                        list.Items.Add(item.ToString());
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Select dll file");
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("DLL or executable program is not a valid managed executable");
            }

}

        private void btnFields_Click(object sender, RoutedEventArgs e)
        {
            SelectFields();
        }

        private void btnProps_Click(object sender, RoutedEventArgs e)
        {
            SelectProperties();
            
        }

        private void btnMethods_Click(object sender, RoutedEventArgs e)
        {
            SelectMethods();
            
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            SelectAllComponents();
            
        }

        //select methods
        void SelectMethods()
        {
            if (assebly != null)
            {
                if (selectedType == null)
                {
                    if (list.SelectedIndex > -1)
                    {
                        selectedType = list.SelectedItem.ToString();
                        GetMethods();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Nothing selected");
                    }
                }
                else
                {
                    GetMethods();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Select DLL");
            }
        }

        //get list of methods
        void GetMethods()
        {
            label.Content = "List of methods";
            list.Items.Clear();

            foreach (var item in type)
            {
                if (item.ToString().Equals(selectedType))
                {
                    var methods = item.GetMethods();

                    if (methods.Length == 0)
                    {
                        System.Windows.MessageBox.Show($"There are no methods");
                    }
                    else
                    {
                        foreach (var method in methods)
                        {
                            list.Items.Add(method.ToString());
                        }
                    }

                }
            }
        }

        //select fields
        void SelectFields()
        {
            if (assebly != null)
            {
                if (selectedType == null)
                {
                    if (list.SelectedIndex > -1)
                    {
                        selectedType = list.SelectedItem.ToString();
                        GetFields();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Nothing selected");
                    }
                }
                else
                {
                    GetFields();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Select DLL");
            }
        }

        //get list of fields
        void GetFields()
        {
            label.Content = "List of fields";
            list.Items.Clear();

            foreach (var item in type)
            {
                if (item.ToString().Equals(selectedType))
                {
                    var fields = item.GetFields();

                    if (fields.Length == 0)
                    {
                        System.Windows.MessageBox.Show("There are no fields");
                    }
                    else
                    {
                        foreach (var field in fields)
                        {
                            list.Items.Add(field.ToString());
                        }
                    }

                }
            }
        }

        //select properties
        void SelectProperties()
        {
            if (assebly != null)
            {
                if (selectedType == null)
                {
                    if (list.SelectedIndex > -1)
                    {
                        selectedType = list.SelectedItem.ToString();
                        GetProperties();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Nothing selected");
                    }
                }
                else
                {
                    GetProperties();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Select DLL");
            }
        }

        //get list of properties
        void GetProperties()
        {
            label.Content = "List of properties";
            list.Items.Clear();

            foreach (var item in type)
            {
                if (item.ToString().Equals(selectedType))
                {
                    var props = item.GetProperties();

                    if (props.Length == 0)
                    {
                        System.Windows.MessageBox.Show("There are no properties");
                    }
                    else
                    {
                        foreach (var prop in props)
                        {
                            list.Items.Add(prop.ToString());
                        }
                    }
                }
            }
        }

        //select all components of type
        void SelectAllComponents()
        {
            if (assebly != null)
            {
                if (selectedType == null)
                {
                    if (list.SelectedIndex > -1)
                    {
                        selectedType = list.SelectedItem.ToString();
                        GetAllComponents();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Nothing selected");
                    }
                }
                else
                {
                    GetAllComponents();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Select DLL");
            }
        }

        //get list of all type's components
        void GetAllComponents()
        {
            label.Content = "List of all type's components";
            list.Items.Clear();

            foreach (var item in type)
            {
                if (item.ToString().Equals(selectedType))
                {
                    foreach (var field in item.GetFields())
                    {
                        list.Items.Add(field.ToString());
                    }

                    foreach (var method in item.GetMethods())
                    {
                        list.Items.Add(method.ToString());
                    }

                    foreach (var prop in item.GetProperties())
                    {
                        list.Items.Add(prop.ToString());
                    }
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
