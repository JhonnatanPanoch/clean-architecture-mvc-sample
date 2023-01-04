namespace CleanArch.Domain.Exceptions
{
    public class DomainExceptionValidations : Exception
    {
        public DomainExceptionValidations(string msg) : base(msg)
        {
        }

        public static void When(bool condition, string msg)
        {
            if (condition)
            {
                throw new DomainExceptionValidations(msg);
            }
        }
    }
}
