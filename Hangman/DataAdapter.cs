using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hangman
{
    public class DataAdapter : BaseAdapter<Profiles>
    {
        private readonly Activity context;
        private readonly List<Profiles> items;

        public DataAdapter(Activity context, List<Profiles> items)
        {
            this.context = context;
            this.items = items;
        }

        public override Profiles this[int position]
        {
            get { return items[position]; }

        }

        public override int Count
        {
            get { return items.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;
            if (view == null) // no view to re-use, create new       
                view = context.LayoutInflater.Inflate(Resource.Layout.Customrow, null);
            view.FindViewById<TextView>(Resource.Id.tvScoreName).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.ScoreWord).Text = item.Word;
            view.FindViewById<TextView>(Resource.Id.tvScoreScore).Text = item.Score.ToString();
          
           view.FindViewById<ImageView>(Resource.Id.ivScoreProfile).SetImageResource(item.ProfilePic);

            //     int num = AddWordAndName.ProfilePic;
            //    ImageView image = (ImageView)num;

           

            //view.FindViewById<ImageView>(Resource.Id.ivScoreProfile).Id = item.ProfilePic;
            //view.FindViewById<ImageView>(Resource.Id.ivScoreProfile).Id = AddWordAndName.ProfilePic;
            return view;
        }
    } 
}