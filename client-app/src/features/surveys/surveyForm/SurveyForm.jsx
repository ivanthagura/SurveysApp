import React, {useState} from 'react';
import { Button, Form, Header, Segment } from 'semantic-ui-react';
import { Link } from 'react-router-dom';

export default function SurveyForm({survey}) {
    const [answers, setAnswers] = useState([]);

    function handleFormSubmit() {
        console.log(answers);
    }

    function handleInputChange(e) {
        const {name, value} = e.target;
        setAnswers({...answers, [name]: value})
    }

    return (
        <Segment clearing>
            <Header content={survey.name} />
            <Form onSubmit={handleFormSubmit}>
                <Form.Field>
                    <input type='text' placeholder='Question 1' name='title' />
                </Form.Field>
                <Form.Field>
                    <input type='text' placeholder='Question 1' />
                </Form.Field>
                <Form.Field>
                    <input type='text' placeholder='Question 1' />
                </Form.Field>
                <Form.Field>
                    <input type='text' placeholder='Question 1' />
                </Form.Field>
                <Form.Field>
                    <input type='text' placeholder='Question 1' />
                </Form.Field>
                <Button type='submit' floated='right' positive content='Submit' />
                <Button as={Link} to={'/surveys'} type='submit' floated='right' positive content='Cancel' />
            </Form>
        </Segment>
    );
}