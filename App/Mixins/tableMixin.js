export default {
    computed: {
        formTitle () {
            return this.editedIndex === -1 ? 'Создать' : 'Редактировать'
        },
        pages () {
            if (this.pagination.rowsPerPage == null || this.pagination.totalItems == null)
                return 0

            return Math.ceil(this.pagination.totalItems / this.pagination.rowsPerPage)
        }
    },  
    watch: {
        dialog (val) {
            val || this.close()
        }
    },  
    created () {
        this.initialize()
    },
    methods: {
        initialize () {
            this.$http.get(this.address)
                .then(
                    response => {
                        if(response.status == 200)
                            this.items = response.body
                        else   
                            console.log('Ошибка загрузки данных!')
                    }
                )
        },  
        editItem (item) {
            this.editedIndex = this.items.indexOf(item)
            this.editedItem = Object.assign({}, item)
            this.dialog = true
        },  
        deleteItem (item) {
            const index = this.items.indexOf(item)
            this.$http.delete(this.address + '/' + item.id)
                .then(
                    response => {
                        if(response.status == 200)
                            this.items.splice(index, 1)
                        else   
                            console.log('Ошибка удаления данных!')
                    }
                )
        },  
        close () {
            this.dialog = false            
            setTimeout(() => {
                this.editedItem = Object.assign({}, this.defaultItem)
                this.editedIndex = -1
                this.$refs.form.reset()
            }, 300)
        },  
        save () {
            if(!this.$refs.form.validate())
                return undefined
            if (this.editedIndex > -1) {
                this.$http.put('/api/' + this.getControllerName,  this.editedItem)
                    .then(
                        response => {
                            if (response.status == 200) {
                                Object.assign(this.items[this.editedIndex], this.editedItem)
                                this.close()
                            } else {
                                console.log('Ошибка обновления данных!')
                                this.close()                            
                            }                                                                    
                        }                        
                    )  
            } else {
                this.$http.post(this.address, this.editedItem)
                    .then(
                        response => {
                            if (response.status == 200) {
                                this.editedItem.id = response.body
                                this.items.push(this.editedItem)
                                this.close()
                            } else {
                                console.log('Ошибка добавления данных!')
                                this.close()
                            }                                                              
                        }
                    )             
            }            
        }
    }
}