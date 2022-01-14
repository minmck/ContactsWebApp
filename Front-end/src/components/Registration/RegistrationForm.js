import axios from "axios";
import { useState } from "react";
import { useHistory } from "react-router-dom";
import { emailIsValid, passwordIsValid, textIsValid } from "../../utils/Validation";
import InfoModal from "../UI/InfoModal";
import UserInput from "../UI/UserInput";
import styles from "./RegistrationForm.module.css";

const RegistrationForm = () => {
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [firstNameInvalid, setFirstNameInvalid] = useState(false);
    const [lastNameInvalid, setLastNameInvalid] = useState(false);
    const [emailInvalid, setEmailInvalid] = useState(false);
    const [passwordInvalid, setPasswordInvalid] = useState(false);
    const [success, setSuccess] = useState(false);
    const history = useHistory();

    const submitHandler = (event) => {
        const data = {
            firstName: firstName,
            lastName: lastName,
            email: email,
            password: password
        }

        if (formIsValid()) {
            axios.post("http://localhost:35549/api/register", data,
            ).then(response => {
                if (response.status === 201) {
                    setSuccess(true);
                }
                console.log('response: ', response);
            }).catch(error => {
                console.log('errors: ', error.response);
            })
        }
        event.preventDefault();
    };

    const handleFirstNameChange = (value) => {
        setFirstName(value);
    };

    const handleLastNameChange = (value) => {
        setLastName(value);
    };

    const handleEmailChange = (value) => {
        setEmail(value);
    };

    const handlePasswordChange = (value) => {
        setPassword(value);
    };

    const formIsValid = () => {
        resetStateErrors();

        let firstNameInv = false;
        let lastNameInv = false;
        let emailInv = false;
        let passwordInv = false;

        if (!textIsValid(firstName)) {
            setFirstNameInvalid(true);
            firstNameInv = true;
        }

        if (!textIsValid(lastName)) {
            setLastNameInvalid(true);
            lastNameInv = true;
        }

        if (!emailIsValid(email)) {
            setEmailInvalid(true);
            emailInv = true;
        }

        if (!passwordIsValid(password)) {
            setPasswordInvalid(true);
            passwordInv = true;
        }

        if (firstNameInv || lastNameInv || emailInv || passwordInv) {
            return false;
        }
        return true;
    };

    const resetStateErrors = () => {
        setFirstNameInvalid(false);
        setLastNameInvalid(false);
        setEmailInvalid(false);
        setPasswordInvalid(false);
    };

    const closeModal = () => {
        setSuccess(false);
        history.push('/login');
    }

    return (
        <form onSubmit={submitHandler}>
            <div>
                <UserInput
                    label='First name:'
                    type='text'
                    value={firstName}
                    onInputChange={handleFirstNameChange}
                    error={firstNameInvalid}
                    errorMessage="First name can't be empty."
                />
                <UserInput
                    label='Last name:'
                    type='text'
                    value={lastName}
                    onInputChange={handleLastNameChange}
                    error={lastNameInvalid}
                    errorMessage="Last name can't be empty."
                />
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
                    errorMessage="Password has to be at least 5 characters long."
                />
            </div>
            {success && <InfoModal message="User created successfully. Please login." onClick={closeModal} />}
            <div className={styles['registration-form__controls']}>
                <button type='submit'>Register</button>
            </div>
        </form>
    );
};

export default RegistrationForm;