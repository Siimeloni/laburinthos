using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.IO;
using Avalonia.Media.Imaging;


namespace laburinthos.ViewModels {
    
    public class MainViewModel : INotifyPropertyChanged {

        private Bitmap currentImage;

        public Bitmap CurrentImage {
            get => currentImage;
            set {
                if (currentImage != value) {
                    currentImage = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateImage(string filePath) {
            if (File.Exists(filePath)) {
                CurrentImage = new Bitmap(filePath);
            }
        }
        
    }
    
}