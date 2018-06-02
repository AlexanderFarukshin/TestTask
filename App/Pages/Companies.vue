<template>
    <div>
        <v-dialog v-model="dialog" max-width="500px">
            <v-btn :small="true" slot="activator" color="primary" dark class="mb-2">Добавить новую компанию</v-btn>     
            <v-card>
                <v-card-title>
                    <span class="headline">{{ formTitle }}</span>
                </v-card-title>
                <v-card-text>
                    <v-form ref="form" v-model="valid" lazy-validation> 
                    <v-container grid-list-md>
                        <v-layout wrap>
                            <v-flex xs12 sm12 md12>
                                <v-text-field :rules="rule" required v-model="editedItem.companyName" label="Название компании"></v-text-field>
                            </v-flex>   
                        </v-layout>
                    </v-container>
                    </v-form>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="blue darken-1" flat @click.native="close">Закрыть</v-btn>
                    <v-btn :disabled="!valid" color="blue darken-1" flat @click.native="save">Сохранить</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
        <v-data-table
            :headers="headers"
            :items="items"
            :pagination.sync="pagination"
            :no-data-text="'В таблице отсутствуют данные'"
            hide-actions
            class="elevation-1"
        >
            <template slot="items" slot-scope="props">
                <td class="text-xs-left">{{ props.item.companyName }}</td>
                <td class="justify-left layout px-0">
                    <v-btn icon class="mx-0" @click="editItem(props.item)">
                        <v-icon color="teal">edit</v-icon>
                    </v-btn>
                    <v-btn icon class="mx-0" @click="deleteItem(props.item)">
                        <v-icon color="pink">delete</v-icon>
                    </v-btn>
                </td>
            </template>
        </v-data-table>
        <div class="text-xs-center pt-2">
            <v-pagination v-model="pagination.page" :length="pages"></v-pagination>
        </div>
    </div>
</template>

<script>
    import tableMixin from '../Mixins/tableMixin'

    export default {
        data: () => ({
            address: '/api/Company',
            valid: true,
            rule: [v => !!v || 'Обязятельное поле'],
            dialog: false,
            pagination: {
                rowsPerPage: 5
            },
            headers: [
                { text: 'Название компании', align: 'left', value: 'companyName' },
                { text: 'Действия', align: 'left', value: 'actions', sortable: false }
            ],
            items: [],
            editedIndex: -1,
            editedItem: {},
            defaultItem: {}
        }),
        mixins: [tableMixin]
    }
</script>