using MVVMProject.Model;
using MVVMProject.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMProject.ViewModel
{
    
    internal class MainWindowViewModel : ViewModelBase
    {
        // Tento řádek vytváří příkaz pro tlačítko „Přidat“
        // RelayCommand říká: "když někdo klikne, zavolej tuto metodu"
        // execute => AddItem() znamená: ignorujeme parametr (exekuce), jen zavoláme metodu AddItem()
        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());

        // Tento řádek vytváří příkaz pro tlačítko „Smazat“
        // Tlačítko se spustí jen tehdy, pokud je vybraná nějaká položka (SelectedItem != null)
        // execute => DeleteItem() říká, co se má stát po kliknutí
        // canExecute => SelectedItem != null říká, zda je tlačítko aktivní
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null);

        // '=>' je jen zkrácený zápis pro malou funkci / metodu, kterou předáváme jako parametr.


        public ObservableCollection<Item> Items { get; set; }
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();
            
            
        }


        private string taskName { get; set; }
        public string TaskName
        {
            get => taskName;
            set
            {
                taskName = value;
                OnPropertyChanged();
            }
        }



        private Item selectedItem;


        public Item SelectedItem
        {
            get { return selectedItem; }
            set { 
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        public string DeadlineText { get; set; }
        private void AddItem()
        {
            if (DateOnly.TryParse(DeadlineText, out var deadline) == false)
            {
                MessageBox.Show("Neplatné datum");
                return;
            }
            ;
            Items.Add(new Item()
            {
                Name = TaskName,
                Deadline = deadline 
            });
        }

        private void DeleteItem()
        {
            Items.Remove(SelectedItem);
        }


    }
}
