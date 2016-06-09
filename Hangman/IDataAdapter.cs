using Android.Views;

namespace Hangman
{
    public interface IDataAdapter
    {
        Profiles this[int position] { get; }

        int Count { get; }

        long GetItemId(int position);
        View GetView(int position, View convertView, ViewGroup parent);
    }
}