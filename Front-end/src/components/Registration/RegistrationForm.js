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
    const [userExists, setUserExists] = useState(false);
    const history = useHistory();

    const submitHandler = (event) => {
        const data = {
            firstName: firstName,
            lastName: lastName,
            email: email,
            password: password
        }

        if (formIsValid()) {
            registerRequest(data);
        }
        event.preventDefault();
    };

    const registerRequest = async (data) => {
        try {
            const response = await axios.post("http://localhost:35549/api/register", data);
            console.log('response: ', response);
            if (response.status === 201) {
                setSuccess(true);
            }
        } catch (error) {
            console.log('error: ', error);
        }
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
        if (success) {
            setSuccess(false);
            history.push('/login');
        }
        if (userExists) {
            setUserExists(false);
        }
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
            {userExists && <InfoModal message="User with this email already exists." onClick={closeModal} />}
            <div className={styles['registration-form__controls']}>
                <button type='submit'>Register</button>
            </div>
        </form>
    );
};

export default RegistrationForm;