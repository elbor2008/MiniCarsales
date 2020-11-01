import React, { memo } from 'react';
import { Label, Input, FormFeedback } from 'reactstrap';

export default memo(({ label, type, errorMsg, isError, ...restProps }) => {
  const { options } = restProps;

  return (
    <>
      <Label>{label}</Label>
      <Input type={type} placeholder={label} {...restProps} invalid={isError}>
        {options && options.map(o => <option key={o.value} value={o.value}>{o.content}</option>)}
      </Input>
      {isError && <FormFeedback>{errorMsg}</FormFeedback>}
    </>
  );
});