package ir.mirhamedrooy;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.TypedValue;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.material.bottomsheet.BottomSheetBehavior;
import com.google.android.material.bottomsheet.BottomSheetDialog;
import com.google.android.material.snackbar.Snackbar;
import com.google.android.material.textfield.TextInputLayout;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;

public class MainActivity extends AppCompatActivity {

    Button Get;
    Button WebSite;
    Button Social;
    TextInputLayout Username;
    TextView textView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Get = findViewById(R.id.Get);
        Username= findViewById(R.id.User);
        WebSite = findViewById(R.id.Website);
        Social = findViewById(R.id.Social_Media);

        Social.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                BottomSheetDialog Social_Media_Bottom_Sheet= new BottomSheetDialog(MainActivity.this);
                View Social_View=getLayoutInflater().inflate(R.layout.social,null);
                Social_Media_Bottom_Sheet.setContentView(Social_View);
                BottomSheetBehavior bottomSheetBehavior= BottomSheetBehavior.from((View) Social_View.getParent());
                bottomSheetBehavior.setPeekHeight((int) TypedValue.applyDimension(TypedValue.COMPLEX_UNIT_DIP,500,getResources().getDisplayMetrics()));
                Social_Media_Bottom_Sheet.show();
            }
        });

        WebSite.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                BottomSheetDialog WebSite_Bottom_Sheet= new BottomSheetDialog(MainActivity.this);
                View WebSite_View=getLayoutInflater().inflate(R.layout.website,null);
                WebSite_Bottom_Sheet.setContentView(WebSite_View);
                BottomSheetBehavior bottomSheetBehavior= BottomSheetBehavior.from((View) WebSite_View.getParent());
                bottomSheetBehavior.setPeekHeight((int) TypedValue.applyDimension(TypedValue.COMPLEX_UNIT_DIP,500,getResources().getDisplayMetrics()));
                WebSite_Bottom_Sheet.show();

//                WebView myWebView=parentView.findViewById(R.id.myWebView);
//                myWebView.loadUrl("https://mirhamedrooy.ir/");
            }
        });

        Get.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                final String EditText_Text=Username.getEditText().getText().toString().trim();
//                textView=findViewById(R.id.textView);

                if (EditText_Text.length()>30){
                    Username.setError("Username Is Too Long!");
                }
                else if (EditText_Text.isEmpty()){
                    Username.setError("You Should Fill Out This Field");
                }
                else {

                    if (Connect()) {


                        Username.setError(null);

                        AsyncTask asyncTask = new AsyncTask() {
                            @Override
                            protected Object doInBackground(Object[] objects) {
                                OkHttpClient client = new OkHttpClient();
                                Request request = new Request.Builder()
                                        .url("https://mirhamedrooy.ir/api/v1/?username=" + EditText_Text)
                                        .build();

                                Response response = null;
                                try {
                                    response = client.newCall(request).execute();
                                    return response.body().string();
                                } catch (IOException e) {
                                    e.printStackTrace();
                                }
                                return null;
                            }

                            @Override
                            protected void onPostExecute(Object o) {
//                                textView.setText(o.toString());

                                String final_json = o.toString();

                                JSONObject object = null;
                                JSONObject rouigram = null;

                                String user_id_User = "";
                                String username_User = "";
                                String fullname_User = "";
                                String profile_hd_photo_User = "";
                                String follower_count_User = "";
                                String following_count_User = "";
                                String media_count_User = "";
                                String external_url_User = "";
                                String is_private_User = "";
                                String biography = "";

                                try {
                                    object = new JSONObject(o.toString());
                                    rouigram = object.getJSONObject("rouigram");

                                    user_id_User = rouigram.getString("user_id");
                                    username_User = rouigram.getString("username");
                                    fullname_User = rouigram.getString("fullname");
                                    profile_hd_photo_User = rouigram.getString("profile_hd_photo");
                                    follower_count_User = rouigram.getString("follower_count");
                                    following_count_User = rouigram.getString("following_count");
                                    media_count_User = rouigram.getString("media_count");
                                    external_url_User = rouigram.getString("external_url");
                                    is_private_User = rouigram.getString("is_private");
                                    biography = rouigram.getString("biography");
                                } catch (JSONException e) {
                                    e.printStackTrace();
                                }

                                Intent intent = new Intent(MainActivity.this, Show.class);

                                intent.putExtra("user_id", user_id_User);
                                intent.putExtra("username", username_User);
                                intent.putExtra("fullname", fullname_User);
                                intent.putExtra("profile_hd_photo", profile_hd_photo_User);
                                intent.putExtra("follower_count", follower_count_User);
                                intent.putExtra("following_count", following_count_User);
                                intent.putExtra("media_count", media_count_User);
                                intent.putExtra("external_url", external_url_User);
                                intent.putExtra("is_private", is_private_User);
                                intent.putExtra("biography", biography);
//
                                startActivity(intent);
                            }
                        }.execute();
                    }
                    else {
                        Snackbar.make(v,"Internet Not Connected", Snackbar.LENGTH_LONG)
                                .setAction("Retry", null /*new Retry()*/).show();
//                        Toast.makeText(MainActivity.this, "Internet Not Connected", Toast.LENGTH_SHORT).show();
                    }
                }
            }
        });
    }

//    @Override
//    public boolean onCreateOptionsMenu(Menu menu) {
//        MenuInflater menuInflater=getMenuInflater();
//        menuInflater.inflate(R.menu.main_menu,menu);
//        return true;
//    }
//
//    @Override
//    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
//        switch (item.getItemId()){
//            case R.id.Setting:
//                Toast.makeText(this, "Settong", Toast.LENGTH_SHORT).show();
//                return true;
//            case R.id.About:
//                Toast.makeText(this, "About", Toast.LENGTH_SHORT).show();
//                Intent intent=new Intent(MainActivity.this,Show.class);
//                startActivity(intent);
//                return true;
//            default:
//                return super.onOptionsItemSelected(item);
//        }
//    }

    private boolean Connect(){
        ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);

        if(connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).getState() == NetworkInfo.State.CONNECTED ||
            connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).getState() == NetworkInfo.State.CONNECTED) {
        return true;
        }

        else
        return false;
        }

//    private class Retry implements View.OnClickListener {
//        @Override
//        public void onClick(View v) {
//            if (Connect()==true) {
//                Snackbar.make(v, "Internetv Connected", Snackbar.LENGTH_LONG)
//                        .show();
//            }
//            else{
//                Snackbar.make(v, "Internet Not Connected", Snackbar.LENGTH_LONG)
//                        .setAction("Retry", new Retry()).show();
//            }
//        }
//    }
}
