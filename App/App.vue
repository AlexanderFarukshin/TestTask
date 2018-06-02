<template>
    <v-app>
        <v-toolbar>
            <v-toolbar-title>Сотрудники и компании</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-items class="hidden-sm-and-down">
                <v-btn flat color="success" to="/employees">Сотрудники</v-btn>
                <v-btn flat color="success" to="/companies">Компании</v-btn>
            </v-toolbar-items>
        </v-toolbar>
        <v-content>
            <v-container fluid>
                <router-view></router-view>
            </v-container>
        </v-content>
    </v-app>
</template>


<script>
    export default {
        
    }
</script>


<style>
</style>