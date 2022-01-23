namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// Base Abstract command for wrapped commands
    /// That integrate a method to return the string method of the command
    /// Also forces use of Execute for all wrapped commands
    /// </summary>
    public abstract class BaseCommand
    {
        public abstract void Execute();

        public string GetMethod()
        {
            return this.GetType().ToString() + "," + nameof(Execute);
        }
    }
}
