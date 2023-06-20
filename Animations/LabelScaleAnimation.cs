namespace BucketList.Animations
{
    class LabelScaleAnimation : TriggerAction<Label>
    {
        protected override async void Invoke(Label sender)
        {
            var animation = new Animation
            {
                { 0, 0.5, new Animation((x) => sender.Scale = x, 1, 1.1) },
                { 0.5, 1, new Animation((x) => sender.Scale = x, 1.1, 1) }
            };

            animation.Commit(sender, nameof(LabelScaleAnimation), length: 2500, 
                repeat: () => true);
        }
    }
}