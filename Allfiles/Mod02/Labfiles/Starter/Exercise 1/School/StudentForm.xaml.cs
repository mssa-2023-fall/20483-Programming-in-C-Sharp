using System;
using System.Windows;

namespace School
{
    /// <summary>
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        #region Predefined code

        public StudentForm()
        {
            InitializeComponent();
        }

        #endregion

        // If the user clicks OK to save the Student details, validate the information that the user has provided
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            //Lab 2 - Exercise 2 
            if(firstName.Text == String.Empty)
            {
                MessageBox.Show("First name is empty.", "Required Field", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (lastName.Text == String.Empty)
            {
                MessageBox.Show("Last name is empty.", "Required Field", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DateTime result;
            if (!DateTime.TryParse(this.dateOfBirth.Text, out result))
            {
                MessageBox.Show("Date of birth must be a valid date.", "Required Field", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            TimeSpan age = DateTime.Now.Subtract(result);
            if( age.Days / 365.25 < 5)
            {
                MessageBox.Show("Student must be at least years old", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            // Indicate that the data is valid
            this.DialogResult = true;
        }
    }
}
