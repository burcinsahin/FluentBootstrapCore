using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class CardGroup : BootstrapComponent,
        ICanCreate<Card>
    {
        public CardGroup() : base("div", Css.CardGroup)
        {
        }

        protected override void PreBuild()
        {
            base.PreBuild();
        }
    }
}
