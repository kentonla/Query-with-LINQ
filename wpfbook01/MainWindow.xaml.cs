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

namespace wpfbook01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Entity Framework DbContext
            var dbcontext = new BooksEntities();

            // get authors and ISBNs of each book they co-authored
            var authorsAndISBNs =
               from author in dbcontext.Authors
               from book in author.Titles
               orderby author.LastName, author.FirstName
               select new { author.FirstName, author.LastName, book.ISBN };

            outputTextBox.AppendText("Authors and ISBNs:");

            // display authors and ISBNs in tabular format
            foreach (var element in __________________)
            {
                outputTextBox.AppendText($"\r\n\t{element.__________________,-10} " +
                   $"{element.__________,-10} {element.ISBN,-10}");
            }

            // get authors and titles of each book they co-authored
            var authorsAndTitles =
               from book in _______________
               from author in __________________
               orderby author.LastName, author.FirstName, _______________
               select new { author.FirstName, author.LastName, _____________ };

            outputTextBox.AppendText("\r\n\r\nAuthors and titles:");

            // display authors and titles in tabular format
            foreach (var element in authorsAndTitles)
            {
                outputTextBox.AppendText($"\r\n\t{element.__________,-10} " +
                   $"{element.___________,-10} {element.____________}");
            }

            // get authors and titles of each book 
            // they co-authored; group by author
            var titlesByAuthor =
               from author in dbcontext.______________
               orderby author.LastName, author.FirstName
               select new
               {
                   Name = author.FirstName + " " +____________________,
                   Titles =
                     from book in _______________
                     orderby book._____________
                     select book.________________
               };

            outputTextBox.AppendText("\r\n\r\nTitles grouped by author:");

            // display titles written by each author, grouped by author
            foreach (var author in _________________)
            {
                // display author's name
                outputTextBox.AppendText($"\r\n\t{______________}:");

                // display titles written by that author
                foreach (var title in ______________)
                {
                    outputTextBox.AppendText($"\r\n\t\t{title}");
                }
            }
        }
    }
}
