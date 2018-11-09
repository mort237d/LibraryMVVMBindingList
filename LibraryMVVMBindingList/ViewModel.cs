using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Graphics.DirectX.Direct3D11;
using Windows.UI.Popups;
using LibraryMVVMBindingList.Annotations;

namespace LibraryMVVMBindingList
{
    class ViewModel : INotifyPropertyChanged
    {
        private ICommand _addLoanerToBook;

        private static string _loaner;

        private Book _selectedBook;

        private ObservableCollection<Book> _books;

        public ViewModel()
        {
            _books = new ObservableCollection<Book>();

            AddLoanerToBook = new RelayCommand(new Action<object>(AddLoanerToSelectedBook));

            _books.Add(new Book("123456789-1234", "Ebbe Vang", "Flæskesteg for begyndere", ""));
            _books.Add(new Book("123456789-4321", "Lars Troelsen", "Frokost på nye måder", "Jacob"));
            _books.Add(new Book("123456789-6789", "Lasse Coinbæk", "Bitcoin i Vipperød", ""));
            _books.Add(new Book("123456789-9876", "Michael Kærgården", "Den som smører godt, kører godt - Glæden ved at cykle!", ""));
        }

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set { _books = value; }
        }

        public string Loaner
        {
            get { return _loaner; }
            set
            {
                _loaner = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddLoanerToBook
        {
            get { return _addLoanerToBook; }
            set { _addLoanerToBook = value; }
        }

        public void AddLoanerToSelectedBook(object obj)
        {
            SelectedBook.Loaner = Loaner;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
