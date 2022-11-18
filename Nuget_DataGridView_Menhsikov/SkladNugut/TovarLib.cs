namespace SkladNugut
{
    public class TovarLib<ST> where ST : class
    {
        private List<ST> Tovars = new List<ST>();

        public TovarLib() { }
        public List<ST> Get()
        {
            return Tovars;
        }

        public void AddTovar(ST tovar)
        {
            Tovars.Add(tovar);
        }

        public void RemoveTovar(ST tovar)
        {
            Tovars.Remove(tovar);
        }

        public void ChangeTovar(int index, ST tovar)
        {
            Tovars[index] = tovar;
        }
    }
}