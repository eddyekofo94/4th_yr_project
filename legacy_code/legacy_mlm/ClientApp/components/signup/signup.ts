import Vue from 'vue';
import Component from 'vue-class-component';

interface Credentials {
    password?: string
    email?: string
    confirmPassword?: string
}

@Component
export default class SignUpComponent extends Vue {
    userCredentials: Credentials;

    data(): Credentials {
        return this.userCredentials
    }

    comparePasswords() {
        return this.userCredentials.password !== this.userCredentials.confirmPassword ? 'Passwords do not match' : ''
        // return this.password !== this.confirmPassword ? 'Passwords do not match' : ''
    }
    user() {
        // return this.$store.getters.user

    }
    onSignup() {
        console.log(this.userCredentials.email, this.userCredentials.password);
        
    }
}