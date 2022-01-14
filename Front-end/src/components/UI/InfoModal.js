import Card from "./Card";
import styles from "./InfoModal.module.css";

const InfoModal = (props) => {
    return (
        <div>
            <div className={styles.backdrop}>
                <Card className={styles.modal}>
                    <p>{props.message}</p>
                    <div className={styles['modal-controls']}>
                        <button onClick={props.onClick}>Ok</button>
                    </div>
                </Card>
            </div>
        </div>
    );
};

export default InfoModal;