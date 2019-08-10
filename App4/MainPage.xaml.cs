using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Storage;
using System.Net.Http;
using Newtonsoft.Json;
using Windows.UI.Core;
using Windows.System;
using static App4.Models.Inventory;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
            KeyboardAccelerator GoBack = new KeyboardAccelerator();
            GoBack.Key = VirtualKey.GoBack;
            GoBack.Invoked += BackInvoked;
            KeyboardAccelerator AltLeft = new KeyboardAccelerator();
            AltLeft.Key = VirtualKey.Left;
            AltLeft.Invoked += BackInvoked;
            this.KeyboardAccelerators.Add(GoBack);
            this.KeyboardAccelerators.Add(AltLeft);
            // ALT routes here
            AltLeft.Modifiers = VirtualKeyModifiers.Menu;

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BackButton.IsEnabled = this.Frame.CanGoBack;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
        }

        // Handles system-level BackRequested events and page-level back button Click events
        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }

        private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }

        IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();
        MobileServiceCollection<TodoItem, TodoItem> items;

        

      

        async private void Submit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                TodoItem item = new TodoItem
                {
                    iPhoneModel = ((ComboBoxItem)comboBox1.SelectedItem).Content.ToString(),
                    Category = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString(),
                    Complete = false,
                    PartName = textBox1.Text,
                    SKU = textBox2.Text,
                    NumberStock = int.Parse(textBox3.Text)

                };

                await App.MobileService.GetTable<TodoItem>().InsertAsync(item);
                var dialog = new MessageDialog("Successful!");
                await dialog.ShowAsync();
                this.Frame.Navigate(typeof(View_Inventory));
            }
            catch (Exception em)
            {
                var dialog = new MessageDialog("An Error Occured: " + em.Message);
                await dialog.ShowAsync();
            }
        }


        //private async Task RefreshTodoItems()
        //{
        //    MobileServiceInvalidOperationException exception = null;
        //    try
        //    {
        //        // This code refreshes the entries in the list view by querying the TodoItems table.
        //        // The query excludes completed TodoItems
        //        items = await todoTable
        //            .Where(TodoItem => TodoItem.Complete == false)
        //            .ToCollectionAsync();
        //    }
        //    catch (MobileServiceInvalidOperationException e)
        //    {
        //        exception = e;
        //    }

        //    if (exception != null)
        //    {
        //        await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
        //    }
        //    else
        //    {
        //        ListItems.ItemsSource = items;
        //        this.btnRefresh.IsEnabled = true;
        //    }
        //}

        //private async void CheckBoxComplete_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cb = (CheckBox)sender;
        //    TodoItem item = cb.DataContext as TodoItem;
        //    await UpdateCheckedTodoItem(item);
        //}

        //private async Task UpdateCheckedTodoItem(TodoItem item)
        //{
        //    // This code takes a freshly completed TodoItem and updates the database. When the MobileService 
        //    // responds, the item is removed from the list 
        //    await todoTable.UpdateAsync(item);
        //    items.Remove(item);
        //    ListItems.Focus(Windows.UI.Xaml.FocusState.Unfocused);

        //    //await SyncAsync(); // offline sync
        //}

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
