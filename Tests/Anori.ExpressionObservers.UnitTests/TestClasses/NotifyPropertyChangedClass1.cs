namespace Anori.ExpressionObservers.UnitTests.TestClasses
{
    public class NotifyPropertyChangedClass1 : Bindable
    {
        private int _intProperty;
        private string _stringProperty;
        private NotifyPropertyChangedClass2 _class2 = new NotifyPropertyChangedClass2();

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


        public const string StringConstant = "Constant";
        public const string NullStringConstant = null;


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

        public NotifyPropertyChangedClass2 Class2
        {
            get => _class2;
            set
            {
                if (Equals(value, _class2)) return;
                _class2 = value;
                OnPropertyChanged();
            }
        }
    }
}