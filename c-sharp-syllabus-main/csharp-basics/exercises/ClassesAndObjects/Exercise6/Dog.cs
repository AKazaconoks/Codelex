namespace Exercise6
{
    public class Dog
    {
        private string name;
        private string sex;
        private Dog mother;
        private Dog father;

        public Dog(string name, string sex)
        {
            this.name = name;
            this.sex = sex;
        }

        public string getName()
        {
            return this.name;
        }

        public void setParents(Dog mother, Dog father)
        {
            this.mother = mother;
            this.father = father;
        }

        public string fathersName()
        {
            try
            {
                return this.father.getName();
            }
            catch
            {
                return "Unknown";
            }
        }
        
        public string mothersName()
        {
            try
            {
                return this.mother.getName();
            }
            catch
            {
                return "Unknown";
            }
        }

        public bool hasSameMother(Dog dog)
        {
            return mothersName() == dog.mothersName();
        }
    }
}