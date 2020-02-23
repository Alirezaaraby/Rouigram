package ir.mirhamedrooy;

import android.content.Intent;
import android.graphics.Color;
import android.hardware.Camera;
import android.os.Bundle;

import com.google.android.material.appbar.CollapsingToolbarLayout;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.android.material.snackbar.Snackbar;
import com.squareup.picasso.Callback;
import com.squareup.picasso.Picasso;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.text.method.LinkMovementMethod;
import android.text.util.Linkify;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import me.saket.bettermovementmethod.BetterLinkMovementMethod;

public class Show extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_show);

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        toolbar.setBackgroundColor(Color.argb(0,255,255,255));

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Share", Snackbar.LENGTH_LONG)
                        .show();
            }
        });

        TextView textView=findViewById(R.id.user_id);
        Intent intent=getIntent();

        String id = intent.getStringExtra("user_id");
        String username = intent.getStringExtra("username");
        String fullname = intent.getStringExtra("fullname");
        String follower_count = intent.getStringExtra("follower_count");
        String following_count = intent.getStringExtra("following_count");
        String media_count = intent.getStringExtra("media_count");
        String external_url = intent.getStringExtra("external_url");
        String is_private = intent.getStringExtra("is_private");
        String profile_hd_photo = intent.getStringExtra("profile_hd_photo");
        String biography = intent.getStringExtra("biography");



        textView.setText("User ID"+":"+id+"\n"+
                            "Username"+":"+username+"\n" +
                            "Fullname"+":"+fullname+"\n"+
                            "Follower Count"+" "+":"+" "+follower_count+"\n"+
                            "Following Count"+" "+":"+" "+following_count+" "+"\n" +
                            "Post Count"+":"+media_count+"\n" +
                            "Website"+":"+external_url+"\n" +
                            "Privacy Status "+":"+is_private+"\n" +
                            "Profile Picture Url"+":"+profile_hd_photo+"\n" +
                            "Biography"+":"+biography+'\n'+'\n'+'\n'+'\n'+'\n'+'\n'+
                            "Coded By Alireza Araby");
        textView.setMovementMethod(LinkMovementMethod.getInstance());
        textView.setTextSize(24);

        textView.setMovementMethod(BetterLinkMovementMethod.newInstance());
        Linkify.addLinks(textView, Linkify.WEB_URLS);

        CollapsingToolbarLayout toolbarLayout = (CollapsingToolbarLayout) findViewById(R.id.toolbar_layout);
        toolbarLayout.setTitle("@"+username);

        final ProgressBar progressBar=findViewById(R.id.progressBar);
        final ImageView imageView=findViewById(R.id.profile_photo);


        progressBar.setVisibility(View.VISIBLE);
        Picasso.get().load(profile_hd_photo).fit().centerCrop()
                .into(imageView, new Callback() {
                    @Override
                    public void onSuccess() {
                        progressBar.setVisibility(View.GONE);
                    }

                    @Override
                    public void onError(Exception e) {

                    }
                });
    }

//    @Override
//    public boolean onCreateOptionsMenu(Menu menu) {
//        MenuInflater menuInflater=getMenuInflater();
//        menuInflater.inflate(R.menu.menu_show,menu);
//        return true;
//    }
//
//    @Override
//    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
//        switch (item.getItemId()){
//            case R.id.Save_Pp:
//                Toast.makeText(this, "Save_Pp", Toast.LENGTH_SHORT).show();
//                return true;
//            case R.id.Save_as_Text:
//                Toast.makeText(this, "Text", Toast.LENGTH_SHORT).show();
//                return true;
//            case R.id.Save_as_ScreenShot:
//                Toast.makeText(this, "ScreenShot", Toast.LENGTH_SHORT).show();
//                return true;
//            default:
//                return super.onOptionsItemSelected(item);
//        }
//    }
}
