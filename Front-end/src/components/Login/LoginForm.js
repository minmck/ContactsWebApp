import axios from "axios";
import { useState } from "react";
import { useHistory } from "react-router-dom";
import { setUserSession } from "../../utils/Common";
import { emailIsValid, textIsValid } from "../../utils/Validation";
import InfoModal from "../UI/InfoModal";
import UserInput from "../UI/UserInput";
import styles from "./LoginForm.module.css";

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [emailInvalid, setEmailInvalid] = useState(false);
    const [passwordInvalid, setPasswordInvalid] = useState(false);
    const [unauthorized, setUnauthorized] = useState(false);
    const history = useHistory();

    const submitHandler = (event) => {
        const data = {
            email: email,
            password: password
        }

        if (formIsValid()) {
            axios.post("http://localhost:35549/api/login", data,
            ).then(response => {
                if (response.status === 200) {
                    setUserSession(response.data.token, response.data.id, response.data.firstName);
                    history.push('/home');
                }
                console.log('response: ', response);
            }).catch(error => {
                setUnauthorized(true);
                console.log('errors: ', error.response);
            })
        }
        event.preventDefault();
    };

    const handleEmailChange = (value) => {
        setEmail(value);
    };

    const handlePasswordChange = (value) => {
        setPassword(value);
    };

    const formIsValid = () => {
        resetStateErrors();

        let emailInv = false;
        let passwordInv = false;

        if (!emailIsValid(email)) {
            setEmailInvalid(true);
            emailInv = true;
        }

        if (!textIsValid(password)) {
            setPasswordInvalid(true);
            passwordInv = true;
        }

        if (emailInv || passwordInv) {
            return false;
        }
        return true;
    };

    const resetStateErrors = () => {
        setEmailInvalid(false);
        setPasswordInvalid(false);
    };

    const closeModal = () => {
        setUnauthorized(false);
    }

    return (
        <form onSubmit={submitHandler}>
            <div>
                <UserInput
                    label='Email address:'
                    type='text'
                    value={email}
                    onInputChange={handleEmailChange}
                    error={emailInvalid}
                    errorMessage="Email is not valid."
                />
                <UserInput
                    label='Password:'
                    type='password'
                    value={password}
                    onInputChange={handlePasswordChange}
                    error={passwordInvalid}
                    errorMessage="Please enter your password."
                />
            </div>
            {unauthorized && <InfoModal message="Email or password is incorrect." onClick={closeModal} />}
            <div className={styles['login-form__controls']}>
                <button type='submit'>Login</button>
            </div>
        </form>
    );
};

export default Login;