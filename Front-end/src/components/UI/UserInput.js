import styles from "./UserInput.module.css";

const UserInput = (props) => {

    const valueChangeHandler = (event) => {
        props.onInputChange(event.target.value);
    };

    return (
        <div className={styles.input}>
            <label>{props.label}</label>
            <input
                type={props.type}
                value={props.value}
                onChange={valueChangeHandler}
            ></input>
            {props.error && <p>*{props.errorMessage}</p>}
        </div>
    );
};

export default UserInput;