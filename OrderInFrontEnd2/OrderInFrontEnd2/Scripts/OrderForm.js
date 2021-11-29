
var orderInput = React.createClass({
    //onchange event
    handleChange: function (e) {
        this.props.onChange(e.target.value);
        var isValidField = this.isValid(e.target);
    },
    //validation Function
    isValid: function (input) {
        if (input.getAttribute('required') != null && input.Value === "") {
            input.classList.add('error');
            input.nextSibling.textContext = this.props.messageRequired;
            return false;
        }
        else {
            input.classList.remove('error');
        }
        input.nextSibling.textContext = "";
    },
    //TODO:orderInput validation
    componentDidMount: function () {
        if (this.props.onComponentMounted) {
            this.props.onComponentMounted(this);
        }

    },
    //render
    render: function () {
        var inputField;
        if (this.props.type == 'textarea') {
            inputField = <textarea value={this.props.value} ref={this.props.name} name={this.props.name} className='form-control' required={this.props.isrequired} OnChange={this.handleChange} />
        }
        else {
            inputField = <input type={this.props.type} value={this.props.value} ref={this.props.name} name={this.props.name} className='form-control' required={this.props.isrequired} OnChange={this.handleChange} />
        }
        return (
            <div className="form-group">
                <label htmlFor={this.props.htmlFor}>{this.props.label}:</label>
                {inputField}
                <span className="error"></span>
            </div>

        );
    }
});


var OrderForm = React.createClass({
    getInitalState: function () {
        return {Location: this.props.Location,
            SearchText: this.props.SearchText,
            Message: this.props.Message,
            Fields: [],
            ServerMessage: ''
        };
    },
    handleSubmit: function (e) {
        e.preventDefault();
        var validForm = true;
        this.state.Fields.forEach(function (field) {
            if (typeof field.isValid === "function") {
                var validField = field.isValued(field.refs[field.props.name]);
                validForm = validForm && validField;
            }
        });
        if (validForm) {
            var d = {
                Location: this.state.Location,
                SearchText: this.state.SearchText,
                Message: this.state.Message
            }

            $.ajax({
                type: "POST",
                url: this.props.urlPost,
                data: d,
                success: function (data) {
                    this.setState({
                        Location: '',
                        SearchText: '',
                        Message: '',
                        ServerMessage: data.message
                    });
                }.bind(this),
                error: function (e) {
                    console.log(e);
                    alert('Error. Please try again.');
                }
            });
        }

    },
    onChangeLocation: function (value) {
        this.setState({
            Location: value
        });
    },
    onChangeSearchText: function (value) {
        this.setState({
            SearchText: value
        });
    },
    onChangeMessage: function (value) {
        this.setState({
            Message: value
        });
    },
    register: function (field) {
        var s = this.state.Fields;
        s.push(field);
        this.setState({
            Fields: s

        })
    },
    render: function () {
        
        return (
            <form name="orderForm" noValdate onSubmit={this.handleSubmit}>
                <orderInput type={'text'} value={this.state.Location} label={'Suburb'} name={'Location'} htmlFor={'Location'} isrequired={true}
                    onChange={this.OnChangeLocation} onComponentMounted={this.register} messageRequired={'Location required'} />
                <orderInput type={'text'} value={this.state.SearchText} label={'SearchText'} name={'SearchText'} htmlFor={'SearchText'} isrequired={false}
                    onChange={this.OnChangeSearchText} onComponentMounted={this.register} messageRequired={'No results for search'} />
                <orderInput type={'text'} value={this.state.Message} label={'Message'} name={'Message'} htmlFor={'Message'} isrequired={false}
                    onChange={this.OnChangeMessage} onComponentMounted={this.register} messageRequired={''} />
                <button type="submit" className="btn btn-default">Submit</button>
                <p className="servermessage">{this.state.ServerMessage}</p>
            </form>
        );
    }
});
    ReactDOM.render(<OrderForm urlPost="/home/SendOrderForm" />, document.getElementById('orderFormArea'));

