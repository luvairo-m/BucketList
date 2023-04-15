namespace BucketList.Animations
{
    class ButtonScaleAnimation : TriggerAction<Button>
    {
        protected override async void Invoke(Button sender)
        {
            await sender.ScaleTo(1.05, 200);
            await sender.ScaleTo(1, 200);
        }
    }
}