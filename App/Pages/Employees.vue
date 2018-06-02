<template>
    <div>
        <v-dialog v-model="dialog" max-width="500px">
            <v-btn :small="true" slot="activator" color="primary" dark class="mb-2">Добавить нового сотрудника</v-btn>     
            <v-card>
                <v-card-title>
                    <span class="headline">{{ formTitle }}</span>
                </v-card-title>
                <v-card-text>
                    <v-form ref="form" v-model="valid" lazy-validation> 
                    <v-container grid-list-md>
                        <v-layout wrap>
                            <v-flex xs12 sm6 md4>
                                <v-text-field :rules="rule" required v-model="editedItem.secondName" label="Фамилия"></v-text-field>
                            </v-flex>
                            <v-flex xs12 sm6 md4>
                                <v-text-field :rules="rule" required v-model="editedItem.firstName" label="Имя"></v-text-field>
                            </v-flex>
                            <v-flex xs12 sm6 md4>
                                <v-text-field :rules="rule" required v-model="editedItem.middleName" label="Отчество"></v-text-field>
                            </v-flex>
                            <v-flex xs12 sm6 md4>
                                <v-text-field :rules="rule" required v-model="editedItem.phoneNumber" label="Телефон"></v-text-field>
                            </v-flex>
                            <v-flex xs12 sm6 md4>
                                <v-select
                                    :items="companies"      
                                    v-model="editedItem.company"
                                    item-text="companyName"
                                    item-value="id"
                                    :rules="rule"
                                    required
                                    return-object
                                    label="Компания"                  
                                >
                                </v-select>
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
                <td class="text-xs-left">{{ props.item.secondName }}</td>
                <td class="text-xs-left">{{ props.item.firstName }}</td>
                <td class="text-xs-left">{{ props.item.middleName }}</td>
                <td class="text-xs-left">{{ props.item.phoneNumber }}</td>
                <td class="text-xs-left">{{ props.item.company.companyName }}</td>
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
            address: '/api/Employee',
            valid: true,
            rule: [v => !!v || 'Обязятельное поле'],
            dialog: false,
            pagination: {
                rowsPerPage: 5
            },
            headers: [
                { text: 'Фамилия',  align: 'left', value: 'secondName' },
                { text: 'Имя',      align: 'left', value: 'firstName' },
                { text: 'Отчество', align: 'left', value: 'middleName' },
                { text: 'Телефон',  align: 'left', value: 'phoneNumber' },
                { text: 'Компания', align: 'left', value: 'companyName' },
                { text: 'Действия', align: 'left', value: 'actions', sortable: false }
            ],
            companies: [],
            items: [],
            editedIndex: -1,
            defaultItem: {},
            editedItem: {}
        }),
        mixins: [tableMixin],
        created () {
            this.$http.get('/api/Company')
                .then(
                    response => {          
                        this.companies = response.body
                        //this.editedItem.company = this.companies[0]
                        //this.defaultItem.company = this.companies[0]
                    }
                )
        }
    } 
</script>

