namespace Exercise6
{
    public class Dog
    {
        private string _name;
        private string _sex;
        private Dog _mother;
        private Dog _father;

        public Dog(string name, string sex)
        {
            _name = name;
            _sex = sex;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetParents(Dog mother, Dog father)
        {
            _mother = mother;
            _father = father;
        }

        public string FathersName()
        {
            try
            {
                return _father.GetName();
            }
            catch
            {
                return "Unknown";
            }
        }
        
        public string MothersName()
        {
            try
            {
                return _mother.GetName();
            }
            catch
            {
                return "Unknown";
            }
        }

        public bool HasSameMother(Dog dog)
        {
            return MothersName() == dog.MothersName();
        }
    }
}