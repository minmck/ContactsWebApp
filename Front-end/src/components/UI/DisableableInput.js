const DisableableInput = (props) => {

    const valueChangeHandler = (event) => {
        props.onInputChange(event.target.value);
    };

    return (
        <input
            type={props.type}
            className={props.className}
            disabled={props.disabled}
            value={props.value}
            onChange={valueChangeHandler}
        ></input>
    );
};

export default DisableableInput;