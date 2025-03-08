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
            var watch = System.Diagnostics.Stopwatch.StartNew();
            InitializeComponent();
            // Entity Framework DbContext
            var dbcontext = new BooksEntities();

            //// get authors and ISBNs of each book they co-authored
            //var authorsAndISBNs =
            //   from author in dbcontext.Authors
            //   from book in author.Titles
            //   orderby author.LastName, author.FirstName
            //   select new { author.FirstName, author.LastName, book.ISBN };

            //outputTextBox.AppendText("Authors and ISBNs:");

            //// display authors and ISBNs in tabular format
            //foreach (var element in authorsAndISBNs)
            //{
            //    outputTextBox.AppendText($"\r\n\t{element.FirstName,-10} " +
            //       $"{element.LastName,-10} {element.ISBN,-10}");
            //}

            // Get a list of all the titles and the authors who wrote them. Sort the result by title.
            var titlesAndAuthors =
               from book in dbcontext.Titles
               from author in book.Authors
               orderby book.Title1
               select new { author.FirstName, author.LastName, book.Title1 };

            outputTextBox.AppendText("\r\n\r\nTitles and Authors:\n");

            // display authors and titles in tabular format
            foreach (var element in titlesAndAuthors)
            {
                outputTextBox.AppendText($"\r\n\t{element.Title1,-10} " +
                   $"{element.FirstName} {element.LastName}");
            }

            // Get a list of all the titles and the authors who wrote them. Sort the result by title.
            // For each title sort the authors alphabetically by last name, then first name.
            var titlesAndAuthors2 =
               from book in dbcontext.Titles
               from author in book.Authors
               orderby book.Title1, author.LastName, author.FirstName
               select new { author.FirstName, author.LastName, book.Title1 };

            outputTextBox.AppendText("\r\n\r\nAuthors and titles with authors sorted for each title:\n");

            // display authors and titles in tabular format
            foreach (var element in titlesAndAuthors2)
            {
                outputTextBox.AppendText($"\r\n\t{element.Title1,-10} " +
                   $"{element.FirstName} {element.LastName}");
            }

            // Get a list of all the authors grouped by title, sorted by title;
            // for a given title sort the author names alphabetically by last name first then first name.
            var authorsByTitle =
               from book in dbcontext.Titles
               orderby book.Title1
               select new
               {
                   Title = book.Title1,
                   Authors = from author in book.Authors
                             orderby author.LastName, author.FirstName
                             select author.FirstName + " " + author.LastName
                
               };

            outputTextBox.AppendText("\r\n\r\nTitles grouped by author:\n");

            // display titles written by each author, grouped by author
            foreach (var book in authorsByTitle)
            {
                // display title of a book
                outputTextBox.AppendText($"\r\n{book.Title}:");

                // display author's name
                foreach (var author in book.Authors)
                {
                    outputTextBox.AppendText($"\r\n\t{author}");
                }
            }

            //displays runtime output
            watch.Stop();
            outputTextBox.AppendText($"\r\n\nRuntime: {watch.ElapsedMilliseconds}ms");
        }
    }
}
