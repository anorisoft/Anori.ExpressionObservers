namespace Anori.ExpressionObservers.UnitTests.TestClasses
{
    public class NotifyPropertyChangedClass2 : Bindable
    {
        private int _intProperty;
        private string _stringProperty;

        public int IntProperty
        {
            get => _intProperty;
            set
            {
                if (value == _intProperty) return;
                _intProperty = value;
                OnPropertyChanged();
            }
        }

        public string StringProperty
        {
            get => _stringProperty;
            set
            {
                if (value == _stringProperty) return;
                _stringProperty = value;
                OnPropertyChanged();
            }
        }
    }
}