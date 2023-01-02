using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrarGPlayGames : MonoBehaviour
{
    public void EntrarComGooglePlayGames()
    {
        Social.localUser.Authenticate((bool success) => 
        {
            if (success) {
                string authCode = GooglePlayGames.PlayGamesPlatform.Instance.GetServerAuthCode();

                Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
                Firebase.Auth.Credential credential = Firebase.Auth.PlayGamesAuthProvider.GetCredential(authCode);
                auth.SignInWithCredentialAsync(credential).ContinueWith(task => 
                {
                    if (task.IsCanceled) 
                    {
                        Debug.LogError("SignInWithCredentialAsync was canceled.");
                        return;
                    }
                    
                    if (task.IsFaulted) 
                    {
                        Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                        return;
                    }
                    
                    Firebase.Auth.FirebaseUser newUser = task.Result;
                    Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
                });
            }

            Debug.Log("Social Local User Authenticate");
        });
    }
}
