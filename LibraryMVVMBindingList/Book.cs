using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LibraryMVVMBindingList.Annotations;

namespace LibraryMVVMBindingList
{
    class Book : INotifyPropertyChanged
    {
        private string _isbn;
        private string _author;
        private string _title;
        private string _loaner;

        public Book(string isbn, string author, string title, string loaner)
        {
            Isbn = isbn;
            Author = author;
            Title = title;
            Loaner = loaner;
        }

        public string Isbn
        {
            get { return _isbn; }
            set { _isbn = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
