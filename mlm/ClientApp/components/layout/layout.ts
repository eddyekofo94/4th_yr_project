import Vue from 'vue';
import Component from 'vue-class-component';

@Component
export default class NavComponent extends Vue {
    drawer: boolean = false;
    source: string ="";
    data: () => ({
        drawer: true
    })
    props: {
        source: String
    }
    messenger() {
        this.$router.push('/messenger')
    }
    counter() {
        this.$router.push('/counter')
    }
}