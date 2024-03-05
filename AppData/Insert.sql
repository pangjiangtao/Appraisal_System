INSERT INTO AppraisalCoefficients(AppraisalType,AppraisalCoefficient,CalculationMethod,IsDel) VALUES('请假','0.1','-1','False')

INSERT INTO AppraisalCoefficients(AppraisalType,AppraisalCoefficient,CalculationMethod,IsDel) VALUES('迟到','0.05','-1','False')

INSERT INTO AppraisalCoefficients(AppraisalType,AppraisalCoefficient,CalculationMethod,IsDel) VALUES('加班','0.1','1','False')

INSERT INTO AppraisalCoefficients(AppraisalType,AppraisalCoefficient,CalculationMethod,IsDel) VALUES('办案数量','0.0005','1','False')

INSERT INTO AppraisalCoefficients(AppraisalType,AppraisalCoefficient,CalculationMethod,IsDel) VALUES('维护次数','0.002','1','False')

INSERT INTO AppraisalCoefficients(AppraisalType,AppraisalCoefficient,CalculationMethod,IsDel) VALUES('项目开发','0.3','1','False')

INSERT INTO AppraisalBases(BaseType,AppraisalBase,IsDel) VALUES('政法编制1','20000','False')

INSERT INTO AppraisalBases(BaseType,AppraisalBase,IsDel) VALUES('行政编制','18000','False')

INSERT INTO AppraisalBases(BaseType,AppraisalBase,IsDel) VALUES('事业编制（管理类）','18000','False')

INSERT INTO AppraisalBases(BaseType,AppraisalBase,IsDel) VALUES('事业编制（专业技术类）','19800','False')

INSERT INTO AppraisalBases(BaseType,AppraisalBase,IsDel) VALUES('事业编制（工勤类）','16000','False')

INSERT INTO AppraisalBases(BaseType,AppraisalBase,IsDel) VALUES('社会化用工','8000','False')

INSERT INTO Users(UserName,Sex,Password,BaseTypeId,IsDel) VALUES('张三','男','111','1','False')

INSERT INTO Users(UserName,Sex,Password,BaseTypeId,IsDel) VALUES('李四','女','111','2','False')

INSERT INTO Users(UserName,Sex,Password,BaseTypeId,IsDel) VALUES('王五','男','111','3','False')

INSERT INTO Users(UserName,Sex,Password,BaseTypeId,IsDel) VALUES('赵六1','女','111','4','False')

INSERT INTO Users(UserName,Sex,Password,BaseTypeId,IsDel) VALUES('田七','男','111','5','False')

INSERT INTO Users(UserName,Sex,Password,BaseTypeId,IsDel) VALUES('周八','女','111','6','False')

INSERT INTO Users(UserName,Sex,Password,BaseTypeId,IsDel) VALUES('吴九','女','111','6','True')

INSERT INTO Users(UserName,Sex,Password,BaseTypeId,IsDel) VALUES('test','男','123456','1','True')

INSERT INTO Users(UserName,Sex,Password,BaseTypeId,IsDel) VALUES('test2','男','111','1','False')

INSERT INTO Users(UserName,Sex,Password,BaseTypeId,IsDel) VALUES('test3','男','111','1','False')

INSERT INTO Users(UserName,Sex,Password,BaseTypeId,IsDel) VALUES('test4','男','111','1','False')


INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('1','1','12','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('1','2','2','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('1','3','12','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('1','4','158','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('1','5','36','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('1','6','3','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('3','1','3','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('3','2','3','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('3','3','6','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('3','4','0','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('3','5','116','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('3','6','0','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('5','1','12','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('5','2','12','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('5','3','2','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('5','4','2','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('5','5','2','2018','False')

INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES('5','6','12','2018','False')

