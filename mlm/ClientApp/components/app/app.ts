import Vue from 'vue';
import * as firebase from 'firebase/app';
import 'firebase/auth';
import 'firebase/database';

import Component from 'vue-class-component';
// import * as firebaseui from 'firebaseui';

interface User {
    DisplayName: string;
    ImageUrl: string;
}

var config = {
    apiKey: "AIzaSyDUlYQ4GoSHNRlQnxGvVgbY_ZBYIISWY5I",
    authDomain: "mlm-firebase.firebaseapp.com",
    databaseURL: "https://mlm-firebase.firebaseio.com",
    storageBucket: "mlm-firebase",
};
firebase.initializeApp(config);


@Component({
    components: {
        MenuComponent: require('../layout/layout.vue.html')
    }
})
export default class AppComponent extends Vue {

    drawer: boolean = false;
    source: string = "";
    // userLoggedIn: boolean = false;

    data: () => ({
        drawer: true
        userLoggedin : true
    })
    props: {
        source: String
    }

    mounted(){
        firebase.auth().onAuthStateChanged(function (user) {
            if (user) {
                // User is signed in.
                console.log("name: email: ",user.displayName, user.email, user.photoURL);
                
            } else {
                console.log("Please login");
                // No user is signed in.
            }
        });
    }

    onLogin() {
        console.log("Test Login");
        var provider = new firebase.auth.GoogleAuthProvider()
        provider.addScope('https://www.googleapis.com/auth/plus.login')

        if (!firebase.auth().currentUser) {
            firebase.auth().signInWithPopup(provider)
                .then(function (result) {
                    // This gives you a Google Access Token. You can use it to access the Google API.
                    var token = result.credential.accessToken;
                    console.log("Tokem" +
                        token + " Result" +
                        result + "\n" + "success")
                })
                .catch(function (error) {
                    console.error("Error", error)
                })
        } else {
            firebase.auth().signOut
        }


    }
    onLogout(){
        firebase.auth().signOut()
    .then(function() {
        // Sign-out successful.
    }).catch(function(error) {
        // An error happened.
    });
    }
    
}
