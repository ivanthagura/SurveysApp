import React from 'react';
import { Button, Form, Header, Segment } from 'semantic-ui-react';

export default function SurveyForm() {
    return (
        <Segment clearing>
            <Header content='Survey details' />
            <Form>
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
                <Form.Field>
                    <input type='text' placeholder='Question 1' />
                </Form.Field>
                <Button type='submit' floated='right' positive content='Submit' />
                <Button type='submit' floated='right' positive content='Cancel' />
            </Form>
        </Segment>
    );
}