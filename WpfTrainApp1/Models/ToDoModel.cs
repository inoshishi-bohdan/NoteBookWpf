using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTrainApp1.Models
{
    public class ToDoModel : INotifyPropertyChanged
    {
        private bool is_done;
        private string text;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDone
        {
            get { return is_done; }
            set 
            {
                if (is_done == value)
                    return;
                is_done = value;
                OnPropertyChanged("IsDone");       
            }
        }
        public string Text
        {
            get { return text; }
            set 
            {
                if (text == value)
                    return;
                text = value;
                OnPropertyChanged("Text");
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = " ")
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
